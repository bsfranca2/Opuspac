const defaultTheme = require("tailwindcss/defaultTheme");

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    colors: {
      white: "#ffffff",
      black: "#000000",
      transparent: "transparent",
      gray: {
        DEFAULT: "#667085",
        25: "#FCFCFD",
        50: "#F9FAFB",
        100: "#F2F4F7",
        200: "#EAECF0",
        300: "#D0D5DD",
        400: "#98A2B3",
        500: "#667085",
        600: "#475467",
        700: "#344054",
        800: "#1D2939",
        900: "#101828",
        950: "#0C111D",
      },
      primary: {
        DEFAULT: "#0BA5EC",
        25: "#F5FBFF",
        50: "#F0F9FF",
        100: "#E0F2FE",
        200: "#B9E6FE",
        300: "#7CD4FD",
        400: "#36BFFA",
        500: "#0BA5EC",
        600: "#0086C9",
        700: "#026AA2",
        800: "#065986",
        900: "#0B4A6F",
        950: "#062C41",
      },
      error: {
        DEFAULT: "#F04438",
        25: "#FFFBFA",
        50: "#FEF3F2",
        100: "#FEE4E2",
        200: "#FECDCA",
        300: "#FDA29B",
        400: "#F97066",
        500: "#F04438",
        600: "#D92D20",
        700: "#B42318",
        800: "#912018",
        900: "#7A271A",
        950: "#55160C",
      },
      warning: {
        DEFAULT: "#F79009",
        25: "#FFFCF5",
        50: "#FFFAEB",
        100: "#FEF0C7",
        200: "#FEDF89",
        300: "#FEC84B",
        400: "#FDB022",
        500: "#F79009",
        600: "#DC6803",
        700: "#B54708",
        800: "#93370D",
        900: "#7A2E0E",
        950: "#4E1D09",
      },
      success: {
        DEFAULT: "#17B26A",
        25: "#F6FEF9",
        50: "#ECFDF3",
        100: "#DCFAE6",
        200: "#ABEFC6",
        300: "#75E0A7",
        400: "#47CD89",
        500: "#17B26A",
        600: "#079455",
        700: "#067647",
        800: "#085D3A",
        900: "#074D31",
        950: "#053321",
      },
    },
    fontFamily: {
      sans: ["Inter", ...defaultTheme.fontFamily.sans],
    },
    fontSize: {
      xs: [
        "0.75rem",
        {
          lineHeight: "1.125rem",
        },
      ],
      sm: [
        "0.875rem",
        {
          lineHeight: "1.25rem",
        },
      ],
      md: [
        "1rem",
        {
          lineHeight: "1.5rem",
        },
      ],
      lg: [
        "1.125rem",
        {
          lineHeight: "1.75rem",
        },
      ],
      xl: [
        "1.25rem",
        {
          lineHeight: "1.875rem",
        },
      ],
      "display-xs": [
        "1.5rem",
        {
          lineHeight: "2rem",
        },
      ],
      "display-sm": [
        "1.875rem",
        {
          lineHeight: "2.375rem",
        },
      ],
      "display-md": [
        "2.25rem",
        {
          lineHeight: "2.75rem",
          letterSpacing: "-0.02rem",
        },
      ],
    },
    boxShadow: {
      xs: "0px 1px 2px 0px rgba(16, 24, 40, 0.05)",
      sm: "0px 1px 2px 0px rgba(16, 24, 40, 0.06), 0px 1px 3px 0px rgba(16, 24, 40, 0.10)",
      md: "0px 2px 4px -2px rgba(16, 24, 40, 0.06), 0px 4px 8px -2px rgba(16, 24, 40, 0.10)",
      lg: "0px 4px 6px -2px rgba(16, 24, 40, 0.03), 0px 12px 16px -4px rgba(16, 24, 40, 0.08)",
      xl: "0px 8px 8px -4px rgba(16, 24, 40, 0.03), 0px 20px 24px -4px rgba(16, 24, 40, 0.08)",
      "2xl": "0px 24px 48px -12px rgba(16, 24, 40, 0.18)",
      "3xl": "0px 32px 64px -12px rgba(16, 24, 40, 0.14)",
    },
    extend: {},
  },
  plugins: [require("tailwindcss-animate"), require("@formkit/themes/tailwindcss")],
};
