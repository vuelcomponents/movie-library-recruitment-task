import PrimeVue from "primevue/config";
import { type App } from "vue";
//@ts-ignore
import Aura from "@/assets/presets/aura";

export function usePrimeVue(app: App): void {
  app.use(PrimeVue, {
    unstyled: true,
    pt: Aura,
  });
}
