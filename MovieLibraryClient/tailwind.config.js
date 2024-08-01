/** @type {import('tailwindcss').Config} */
export default {
  content: ["./*.html", "./src/**/*.{js,jsx,ts,tsx,vue}"],
  darkMode: "media",
  theme: {
    extend: {
      fontFamily: {
        mulish: "Mulish, sans-serif",
      },
      height: {
        'full-minus-20': 'calc(100% - 5rem)',
      },
      widows:{
        'full-minus-20': 'calc(100% - 5rem)',
      }
    },
  },
  plugins: [require("tailwindcss-primeui")],
};
