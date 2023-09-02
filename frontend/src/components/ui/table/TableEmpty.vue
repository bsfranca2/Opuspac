<script setup lang="ts">
import TableRow from "./TableRow.vue";
import TableCell from "./TableCell.vue";
import { cn } from "@/lib/utils";

interface Props {
  class?: string;
  colspan?: number;
}

const props = withDefaults(defineProps<Props>(), {
  class: "",
  colspan: 1,
});
</script>

<template>
  <TableRow>
    <!-- TODO: Review this color -->
    <TableCell
      :class="cn('text-foreground whitespace-nowrap p-4 align-middle text-sm', props.class)"
      :colspan="props.colspan"
    >
      <div class="flex items-center justify-center py-10">
        <slot />
      </div>
    </TableCell>
  </TableRow>
</template>
