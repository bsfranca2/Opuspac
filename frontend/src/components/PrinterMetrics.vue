<script setup lang="ts">
import type { PrinterMetrics } from "@/api/types";
import { computed } from "vue";

interface Props {
  metrics: PrinterMetrics;
}

const props = defineProps<Props>();

const labels: Record<string, string> = {
  printerAgentsConnected: "Agentes Conectados",
  printJobsWaiting: "Tarefas na Fila",
  printJobsError: "Erros de Impressão",
};

const stats = computed(() => {
  return Object.entries(props.metrics).map(([key, value]) => ({
    name: labels[key],
    stat: value,
  }));
});
</script>

<template>
  <dl class="grid grid-cols-1 gap-5 sm:grid-cols-3">
    <div
      v-for="item in stats"
      :key="item.name"
      class="overflow-hidden rounded-xl border border-gray-200 bg-white px-4 py-5 sm:p-6"
    >
      <dt class="truncate text-sm font-medium text-gray-600">{{ item.name }}</dt>
      <dd class="mt-2 text-display-md font-semibold tabular-nums text-gray-900">{{ item.stat }}</dd>
    </div>
  </dl>
</template>
