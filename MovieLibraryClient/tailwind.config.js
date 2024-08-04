/** @type {import('tailwindcss').Config} */
export default {
  content: ["./*.html", "./src/**/*.{js,jsx,ts,tsx,vue}"],
  darkMode: "media",
  theme: {
    extend: {
      flex:{
        'full-center':'h-full w-full flex items-center',
      },
      colors: {
        surface:{
          0:'#020d18',
          100:'#233a50',
          200:'#abb7c4',
          300:'#dee1e5',
          400:'#e6e9ec'
        },
        movieTheme:{
          0:'#dcf836',
          100:'#a6bb16',
          200:'#dd003f',
          300:'#ec5a1a',
        }
      },
      fontFamily: {
        mulish: "Mulish, sans-serif",
      },
      height: {
        'full-minus-20': 'calc(100% - 5rem)',
        'screen-minus-headers':'calc(100vh - 10rem)'
      },
      width:{
        'full-minus-20': 'calc(100% - 5rem)',
      }
    },
  },
  plugins: [require("tailwindcss-primeui")],
};
