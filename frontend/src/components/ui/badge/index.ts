import { cva } from "class-variance-authority";

export { default as Badge } from "./Badge.vue";

export const badgeVariants = cva(
  "inline-flex items-center gap-x-1 rounded-2xl font-medium ring-1 ring-inset",
  {
    variants: {
      variant: {
        default: "bg-white text-gray-700 ring-gray-200",
      },
      size: {
        sm: "px-1.5 py-0.5 text-xs",
      },
    },
    defaultVariants: {
      variant: "default",
      size: "sm",
    },
  }
);
