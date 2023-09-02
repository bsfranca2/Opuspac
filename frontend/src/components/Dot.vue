<script setup lang="ts">
import { cn } from "@/lib/utils";
</script>

<template>
  <svg :class="cn('fill-primary h-1.5 w-1.5', $attrs.class ?? '')" viewBox="0 0 6 6" aria-hidden="true">
    <circle cx="3" cy="3" r="3" />
  </svg>
</template>
