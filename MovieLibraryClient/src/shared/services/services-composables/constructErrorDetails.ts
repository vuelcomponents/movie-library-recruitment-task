export const constructErrorDetail = (error: any): any => {
  if (typeof error === "string") {
    return error;
  }
  if (error?.errors) {
    return Array.from(Object.values(error.errors)).join(", ");
  }
  return "";
};
