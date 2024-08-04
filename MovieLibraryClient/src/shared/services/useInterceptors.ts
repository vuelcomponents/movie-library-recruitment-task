import type {
  AxiosError,
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";
import { TinyEmitter } from "tiny-emitter";
import { constructErrorDetail } from "./services-composables/constructErrorDetails.ts";
import { constructToastMessage } from "../composables/constructToastMessage.ts";

interface InterceptorParams {
  client: AxiosInstance;
  emitter: TinyEmitter;
}
let sent = false;

export default (params: InterceptorParams) => {
  params.client.interceptors.request.use(
    (req: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
      if (params.emitter) {
        params.emitter.emit("load", true);
      }
      sent = false;
      return req;
    },
  );
  params.client.interceptors.response.use(
    (res: AxiosResponse): AxiosResponse => {
      if (params.emitter) {
        params.emitter.emit("load", false);
      }
      switch (res?.status) {
        case 200:
          switch (res.config?.method) {
            case "patch":
              if (!sent) {
                const [updateResType, updateResContent] = constructToastMessage(
                  "info",
                  "Entity has been updated",
                  "",
                );
                params.emitter.emit(updateResType, updateResContent);
                sent = true;
              }
              break;
          }
          break;
        default:
          break;
      }
      return res;
    },
    (error: AxiosError) => {
      params.emitter.emit("load", false);
      console.log(error)
      if (params.emitter) {
        switch (error?.response?.status) {
          default:
            const [errorType, errorContent] = constructToastMessage(
              "error",
              `${error.message}`,
              constructErrorDetail(error.response?.data),
            );
            params.emitter.emit(errorType, errorContent);
        }
      }
      return error;
    },
  );
};
