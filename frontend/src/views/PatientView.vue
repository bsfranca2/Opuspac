<script setup lang="ts">
import { useQuery } from "@tanstack/vue-query";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import Patient from "@/components/Patient.vue";
import { getPatients } from "@/api";
import { generateAvatarName } from "@/lib/avatar";

const { isLoading, data: patients } = useQuery({
  queryKey: ["patients"],
  queryFn: getPatients,
});
</script>

<template>
  <div class="flex items-start justify-between">
    <div>
      <h2 class="mb-1 text-display-sm font-semibold">Pacientes</h2>
      <p class="text-gray-600">Visualize e gerencie os registros dos pacientes.</p>
    </div>
    <div><Patient /></div>
  </div>
  <div class="mt-8">
    <div v-if="isLoading">Carregando prescrições...</div>
    <div v-else class="rounded-md border">
      <Table>
        <TableHeader class="bg-gray-50">
          <TableRow>
            <TableHead width="90"></TableHead>
            <TableHead>Paciente</TableHead>
            <TableHead>Setor/Leito</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <TableRow v-for="patient in patients" :key="patient.id">
            <TableCell>
              <Avatar size="sm">
                <AvatarImage :alt="patient.name" />
                <AvatarFallback>{{ generateAvatarName(patient.name) }}</AvatarFallback>
              </Avatar>
            </TableCell>
            <TableCell class="font-medium text-gray-900">{{ patient.name }}</TableCell>
            <TableCell>{{ patient.bed }}</TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </div>
  </div>
</template>
