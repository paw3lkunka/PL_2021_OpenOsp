module.exports = {
  mode: 'jit',
  purge: [
    './wwwroot/index.html',
    './**/*.razor',
  ],
  darkMode: false,
  theme: {
    extend: {
      backgroundImage: theme => ({
        'firefighters': "url('https://live.staticflickr.com/5463/7415300266_98586c85a4_k.jpg')"
      })
    }
  },
  variants: {
    extend: {}
  },
  plugins: [
    require('daisyui'),
    require('tailwindcss-textshadow'),
  ],
  daisyui: {
    styled: true,
    themes: [
      'dark',
      'light'
    ],
    base: true,
    utils: true,
    logs: true,
    rtl: false,
  }
}