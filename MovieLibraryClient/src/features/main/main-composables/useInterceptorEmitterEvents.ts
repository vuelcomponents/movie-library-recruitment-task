import { onMounted, ref } from "vue";
import { ToastMessageOptions } from "primevue/toast";
import { TinyEmitter } from "tiny-emitter";
import { ToastServiceMethods } from "primevue/toastservice";

export const useInterceptorEmitterEvents = (
  toast: ToastServiceMethods,
  emitter: TinyEmitter,
) => {
  const loadingState = ref<boolean>(false);
  onMounted(() => {
    emitter.on("load", (state: boolean) => {
      loadingState.value = state;
    });
    emitter.on("error", (params: ToastMessageOptions) => {
      toast.add(params);
      console.error(params.summary, params.detail);
    });
  });
  return {
    loadingState,
  };
};
