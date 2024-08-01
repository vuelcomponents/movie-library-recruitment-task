import type {
  AxiosError,
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";
import { TinyEmitter } from "tiny-emitter";

interface InterceptorParams {
  client: AxiosInstance;
  emitter: TinyEmitter;
}
let sent = false;
const constructErrorDetail = (error: any): any => {
  if (typeof error === "string") {
    return error;
  }
  if (error?.errors) {
    return Array.from(Object.values(error.errors)).join(", ");
  }
  return "";
};

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
                params.emitter.emit("info", {
                  severity: "info",
                  summary: "rowHasBeenUpdated",
                  detail: "",
                  life: 3000,
                });
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
      if (params.emitter) {
        switch (error?.response?.status) {
          default:
            params.emitter.emit("error", {
              severity: "error",
              summary: `${error.message}`,
              detail: constructErrorDetail(error.response?.data),
              life: 3000,
            });
        }
      }
      return error;
    },
  );
};
