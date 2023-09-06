<script setup lang="ts">
import {
  DialogClose,
  DialogContent,
  type DialogContentEmits,
  type DialogContentProps,
  DialogOverlay,
  DialogPortal,
} from "radix-vue";
import IconX from "~icons/op/x-close";
import { cva } from "class-variance-authority";
import { cn, useEmitAsProps } from "@/lib/utils";

interface SheetContentProps extends DialogContentProps {
  class?: string;
}

const props = defineProps<SheetContentProps>();

const emits = defineEmits<DialogContentEmits>();

const emitsAsProps = useEmitAsProps(emits);

const sheetVariants = cva(
  "fixed z-50 gap-4 bg-white p-6 shadow-lg transition ease-in-out data-[state=closed]:duration-300 data-[state=open]:duration-500 data-[state=open]:animate-in data-[state=closed]:animate-out",
  {
    variants: {
      side: {
        right:
          "inset-y-0 right-0 h-full w-3/4  overflow-y-auto border-l border-gray-200 data-[state=closed]:slide-out-to-right data-[state=open]:slide-in-from-right sm:max-w-sm md:max-w-md",
      },
    },
    defaultVariants: {
      side: "right",
    },
  }
);
</script>

<template>
  <DialogPortal>
    <DialogOverlay
      class="fixed inset-0 z-50 bg-white/80 backdrop-blur-sm data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0"
    />
    <DialogContent :class="cn(sheetVariants(), props.class)" v-bind="{ ...props, ...emitsAsProps }">
      <slot />

      <DialogClose class="absolute right-4 top-4 rounded-md p-0.5 transition-colors hover:bg-gray-100">
        <IconX class="h-4 w-4 text-gray-500" />
      </DialogClose>
    </DialogContent>
  </DialogPortal>
</template>
