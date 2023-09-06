<script setup lang="ts">
import { Button } from "@/components/ui/button";
import IconPlus from "~icons/op/plus";
import IconPrinter from "~icons/op/printer";
import IconEdit from "~icons/op/edit";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Tooltip, TooltipContent, TooltipProvider, TooltipTrigger } from "@/components/ui/tooltip";

const prescriptions = [
  {
    id: 0,
    patientName: "Paciente Teste",
    prescriptionCode: "1",
    attendantId: "123",
    time: "12:00",
  },
];
</script>

<template>
  <div class="flex items-start justify-between">
    <div>
      <h2 class="mb-1 text-display-sm font-semibold">Prescrições</h2>
      <p class="text-gray-600">Aqui estão todas as prescrições médicas registradas.</p>
    </div>
    <div>
      <Button>
        <IconPlus class="mr-2 h-5 w-5" />
        Adicionar
      </Button>
    </div>
  </div>
  <div class="mt-8">
    <div class="rounded-md border">
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
            <TableCell>{{ prescription.prescriptionCode }}</TableCell>
            <TableCell class="font-medium text-gray-900">{{ prescription.patientName }}</TableCell>
            <TableCell>{{ prescription.time }}</TableCell>
            <TableCell>{{ prescription.attendantId }}</TableCell>
            <TableCell class="flex items-center justify-center gap-x-1">
              <TooltipProvider>
                <Tooltip :delay-duration="0">
                  <TooltipTrigger as-child>
                    <Button variant="icon" size="icon">
                      <IconEdit class="h-5 w-5" />
                    </Button>
                  </TooltipTrigger>
                  <TooltipContent>
                    <p>Editar</p>
                  </TooltipContent>
                </Tooltip>
              </TooltipProvider>
              <TooltipProvider>
                <Tooltip :delay-duration="0">
                  <TooltipTrigger as-child>
                    <Button variant="icon" size="icon">
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
