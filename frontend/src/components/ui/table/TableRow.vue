<script setup lang="ts">
import { cn } from "@/lib/utils";

const props = defineProps<{ class?: string }>();
</script>

<template>
  <tr
    :class="
      cn('data-[state=selected]:bg-bg-gray-50 border-b transition-colors hover:bg-gray-50', props.class)
    "
  >
    <slot />
  </tr>
</template>
