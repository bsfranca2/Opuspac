<script setup lang="ts">
import { cn } from "@/lib/utils";

const props = defineProps<{ class?: string }>();
</script>

<template>
  <th
    :class="
      cn(
        'h-11 px-6 py-3 text-left align-middle font-medium text-gray-600 [&:has([role=checkbox])]:pr-0',
        props.class
      )
    "
  >
    <slot />
  </th>
</template>
