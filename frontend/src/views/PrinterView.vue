<script setup lang="ts">
import Dot from "@/components/Dot.vue";
import PrinterMetrics from "@/components/PrinterMetrics.vue";
import { Badge } from "@/components/ui/badge";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { useQuery } from "@tanstack/vue-query";
import { getPrinterMetrics, getPrinterAgents } from "@/api";

const simulateRealtimeUpdates = {
  refetchOnWindowFocus: true,
  refetchInterval: 5000,
};

const { isLoading: metricsIsLoading, data: metrics } = useQuery({
  queryKey: ["printer-metrics"],
  queryFn: getPrinterMetrics,
  ...simulateRealtimeUpdates,
});

const { isLoading: agentsIsLoading, data: agents } = useQuery({
  queryKey: ["printer-agents"],
  queryFn: getPrinterAgents,
  ...simulateRealtimeUpdates,
});

function formatDate(dateStr: string | null) {
  if (!dateStr) return null;
  return new Intl.DateTimeFormat("pt-BR", {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit",
    hour12: false,
  }).format(new Date(dateStr));
}
</script>

<template>
  <div class="mb-8">
    <h2 class="text-display-sm font-semibold">Impressoras</h2>
  </div>
  <div>
    <span v-if="metricsIsLoading">Carregando métricas...</span>
    <PrinterMetrics v-else-if="!!metrics" :metrics="metrics" />
    <div class="mb-6 mt-8">
      <h3 class="mb-1 text-lg font-semibold">Agentes</h3>
      <p class="text-sm text-gray-600">Aqui estão os computadores que executam as impressões.</p>
    </div>
    <div v-if="agentsIsLoading">Carregando agents...</div>
    <div v-else class="rounded-md border">
      <Table>
        <TableHeader class="bg-gray-50">
          <TableRow>
            <TableHead>Agente</TableHead>
            <TableHead>Impressora</TableHead>
            <TableHead>IP</TableHead>
            <TableHead>Status</TableHead>
            <TableHead>Data da Última Conexão</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <TableRow v-for="agent in agents" :key="agent.id">
            <TableCell class="font-medium text-gray-900">{{ agent.name }}</TableCell>
            <TableCell>{{ agent.printerModel }}</TableCell>
            <TableCell>{{ agent.ip }}</TableCell>
            <TableCell>
              <Badge>
                <span class="relative">
                  <span
                    v-if="agent.isConnected"
                    class="absolute inline-flex h-full w-full animate-ping rounded-full bg-success-400 opacity-75"
                  />
                  <Dot :class="[agent.isConnected ? 'fill-success' : 'fill-gray']" />
                </span>
                {{ agent.isConnected ? "Ativo" : "Inativo" }}
              </Badge>
            </TableCell>
            <TableCell>{{ formatDate(agent.lastActiveConnectionDate) }}</TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </div>
  </div>
</template>
