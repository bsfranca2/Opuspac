<script setup lang="ts">
import { Label, type LabelProps } from "radix-vue";
import { cn } from "@/lib/utils";

const props = defineProps<LabelProps & { class?: string }>();
</script>

<template>
  <!-- TODO: Verificar essa cor -->
  <Label
    v-bind="props"
    :class="cn('block text-left text-sm font-medium tracking-tight text-gray-700', props.class)"
  >
    <slot />
  </Label>
</template>
