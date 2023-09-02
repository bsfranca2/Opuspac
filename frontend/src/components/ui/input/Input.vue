<script setup lang="ts">
import { cn } from "@/lib/utils";

defineProps<{
  defaultValue?: string | number;
}>();
</script>

<template>
  <input
    type="text"
    :value="defaultValue"
    :class="
      cn(
        'file:bg-transparent focus-visible:ring-ring flex h-10 w-full rounded-md border border-gray-200 bg-white px-3 py-2 text-sm ring-offset-white file:border-0 file:text-sm file:font-medium placeholder:text-gray-500 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-offset-2 disabled:cursor-not-allowed disabled:opacity-50',
        $attrs.class ?? ''
      )
    "
  />
</template>
