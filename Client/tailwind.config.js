const colors = require('tailwindcss/colors')

module.exports = {
  mode: 'jit',
  purge: [
    './wwwroot/index.html',
    './**/*.razor',
  ],
  darkMode: false,
  theme: {
    extend: {
      colors: {
        'openosp': {
          'primary': '#e25c28',
          'secondary': '#adadad',
          'bg': {
            'light': '#2e3838',
            'dark': '#160f29'
          }
        }
      },
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
  ]
}