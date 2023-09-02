import { cva } from "class-variance-authority";

export { default as Button } from "./Button.vue";

export const buttonVariants = cva(
  "focus-visible:ring-ring inline-flex items-center justify-center rounded-lg text-sm font-semibold transition-colors focus-visible:outline-none focus-visible:ring-1 disabled:pointer-events-none disabled:opacity-50",
  {
    variants: {
      variant: {
        default: "bg-primary-600 text-white shadow-xs hover:bg-primary-700",
        // destructive:
        //   'bg-destructive text-destructive-foreground hover:bg-destructive/90 shadow-sm',
        // outline:
        //   'border-input hover:bg-accent hover:text-accent-foreground border bg-transparent shadow-sm',
        // secondary:
        //   'bg-secondary text-secondary-foreground hover:bg-secondary/80 shadow-sm',
        // ghost: 'hover:bg-accent hover:text-accent-foreground',
        // link: 'text-primary underline-offset-4 hover:underline',
      },
      size: {
        default: "h-10 px-4 py-2.5",
        sm: "h-9 px-3.5 py-2",
        lg: "h-11 px-[1.125rem] py-2.5 text-md",
        // icon: 'h-10 w-10',
      },
    },
    defaultVariants: {
      variant: "default",
      size: "default",
    },
  }
);
