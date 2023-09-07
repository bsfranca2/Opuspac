<script setup lang="ts">
import { AvatarRoot } from "radix-vue";
import { avatarVariant } from ".";
import { cn } from "@/lib/utils";

interface Props {
  size?: NonNullable<Parameters<typeof avatarVariant>[0]>["size"];
  class?: string;
}

const props = withDefaults(defineProps<Props>(), {
  size: "base",
});
</script>

<template>
  <AvatarRoot :class="cn(avatarVariant({ size }), props.class)">
    <slot />
  </AvatarRoot>
</template>
