import { ToastMessageOptions } from "primevue/toast";

export function constructToastMessage(
  severity: "info" | "error" | "success" | "warn" | "secondary" | "contrast",
  summary: string,
  detail: string,
  life?: number,
): [string, ToastMessageOptions] {
  return [
    severity,
    {
      severity,
      summary,
      detail,
      life: life ?? 3000,
    },
  ];
}
