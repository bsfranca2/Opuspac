<script setup lang="ts">
import { useQuery } from "@tanstack/vue-query";
import { Button } from "@/components/ui/button";
import IconPrinter from "~icons/op/printer";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Tooltip, TooltipContent, TooltipProvider, TooltipTrigger } from "@/components/ui/tooltip";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import Prescription from "@/components/Prescription.vue";
import { getPrescriptions, postPrintJob } from "@/api";
import { generateAvatarName } from "@/lib/avatar";

const { isLoading, data: prescriptions } = useQuery({
  queryKey: ["prescriptions"],
  queryFn: getPrescriptions,
});

async function print(prescriptionId: string) {
  await postPrintJob({ prescriptionId });
  alert("Solicitação de impressão enviado!");
}
</script>

<template>
  <div class="flex items-start justify-between">
    <div>
      <h2 class="mb-1 text-display-sm font-semibold">Prescrições</h2>
      <p class="text-gray-600">Aqui estão todas as prescrições médicas registradas.</p>
    </div>
    <div><Prescription /></div>
  </div>
  <div class="mt-8">
    <div v-if="isLoading">Carregando prescrições...</div>
    <div v-else class="rounded-md border">
      <Table>
        <TableHeader class="bg-gray-50">
          <TableRow>
            <TableHead>Prescrição nº</TableHead>
            <TableHead>Paciente</TableHead>
            <TableHead>Horário</TableHead>
            <TableHead>Atendimento</TableHead>
            <TableHead class="text-center">Ações</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <TableRow v-for="prescription in prescriptions" :key="prescription.id">
            <TableCell>{{ prescription.code }}</TableCell>
            <TableCell class="inline-flex items-center gap-x-3">
              <Avatar size="sm">
                <AvatarImage :alt="prescription.patient.name" />
                <AvatarFallback>{{ generateAvatarName(prescription.patient.name) }}</AvatarFallback>
              </Avatar>
              <div>
                <p class="font-medium text-gray-900">{{ prescription.patient.name }}</p>
                <p class="text-gray-600">{{ prescription.patient.bed }}</p>
              </div>
            </TableCell>
            <TableCell>{{ prescription.time }}</TableCell>
            <TableCell>{{ prescription.attendantId }}</TableCell>
            <TableCell class="flex items-center justify-center gap-x-1">
              <TooltipProvider>
                <Tooltip :delay-duration="0">
                  <TooltipTrigger as-child>
                    <Button variant="icon" size="icon" @click="print(prescription.id)">
                      <IconPrinter class="h-5 w-5" />
                    </Button>
                  </TooltipTrigger>
                  <TooltipContent>
                    <p>Imprimir</p>
                  </TooltipContent>
                </Tooltip>
              </TooltipProvider>
            </TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </div>
  </div>
</template>
