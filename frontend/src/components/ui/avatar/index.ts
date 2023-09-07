import { cva } from "class-variance-authority";

export { default as Avatar } from "./Avatar.vue";
export { default as AvatarImage } from "./AvatarImage.vue";
export { default as AvatarFallback } from "./AvatarFallback.vue";

export const avatarVariant = cva(
  "inline-flex shrink-0 select-none items-center justify-center overflow-hidden rounded-full border border-gray-900/[.08] bg-gray-100 font-semibold text-gray-600",
  {
    variants: {
      size: {
        sm: "h-8 w-8 text-sm",
        base: "h-10 w-10 text-md",
      },
    },
  }
);
