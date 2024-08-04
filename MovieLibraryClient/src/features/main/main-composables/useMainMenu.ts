export type HorizontalMenuItem = {
  label: string;
  main?: boolean;
};
export const useMainMenu = (): HorizontalMenuItem[] => {
  return [
    {
      label: "Home",
      main: true,
    },
    {
      label: "Movies",
    },
  ];
};
