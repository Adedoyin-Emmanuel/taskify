/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Views/**/*.{html,js,cshtml}"],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["wireframe"],
  },
};
