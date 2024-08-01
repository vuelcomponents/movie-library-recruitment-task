/** @type {import('tailwindcss').Config} */
export default {
  content: ["./*.html", "./src/**/*.{js,jsx,ts,tsx,vue}"],
  darkMode: "media",
  theme: {
    extend: {
      fontFamily: {
        mulish: "Mulish, sans-serif",
      },
    },
  },
  plugins: [require("tailwindcss-primeui")],
};
