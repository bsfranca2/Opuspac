<script setup lang="ts">
import { cn } from "@/lib/utils";

const props = defineProps<{ class?: string }>();
</script>

<template>
  <td :class="cn('px-6 py-4 align-middle text-gray-600 [&:has([role=checkbox])]:pr-0', props.class)">
    <slot />
  </td>
</template>
