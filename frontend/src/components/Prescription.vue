<script setup lang="ts">
import { useQuery, useQueryClient } from "@tanstack/vue-query";
import { computed, ref } from "vue";
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetTrigger } from "@/components/ui/sheet";
import IconPlus from "~icons/op/plus";
import { Button } from "@/components/ui/button";
import { administrationInstructions } from "@/config/administrationInstructions";
import { getPatients, postPrescriptions } from "@/api";
import type { CreatePrescription } from "@/api/types";

const open = ref(false);

const administrationInstructionsOptions = administrationInstructions.map((instructions) => ({
  value: instructions,
  label: instructions,
}));

const { data: patients } = useQuery({
  queryKey: ["patients"],
  queryFn: getPatients,
});
const patientsOptions = computed(() => {
  return (patients.value ?? []).map((patient) => ({ value: patient.id, label: patient.name }));
});

const queryClient = useQueryClient();
async function submitHandler(data: CreatePrescription) {
  await postPrescriptions(data);
  queryClient.invalidateQueries(["prescriptions"]);
  open.value = false;
}
</script>

<template>
  <Sheet v-model:open="open">
    <SheetTrigger as-child>
      <Button>
        <IconPlus class="mr-2 h-5 w-5" />
        Adicionar
      </Button>
    </SheetTrigger>
    <SheetContent>
      <SheetHeader>
        <SheetTitle>Adicionar Prescrição</SheetTitle>
      </SheetHeader>
      <div class="mt-4">
        <FormKit type="form" @submit="submitHandler" submit-label="Salvar">
          <FormKit type="number" name="code" label="Prescrição nº" validation="required" placeholder="123" />
          <FormKit
            type="autocomplete"
            name="patientId"
            label="Paciente"
            validation="required"
            placeholder="Paciente Teste"
            :options="patientsOptions"
          />
          <FormKit
            type="number"
            name="attendantId"
            label="Atendimento"
            validation="required"
            placeholder="123"
          />
          <FormKit type="time" name="time" label="Horário" validation="required" placeholder="00:00" />
          <FormKit type="repeater" name="medicines" label="Medicamentos" add-label="Adicionar Medicamento">
            <FormKit
              type="text"
              name="name"
              label="Nome do medicamento"
              validation="required"
              placeholder="Ex: Acetilcistenia AMP 100mg"
            />
            <FormKit
              type="dropdown"
              name="administrationInstructions"
              label="Forma Administrativa"
              placeholder="Ex: Oral"
              validation="required"
              :options="administrationInstructionsOptions"
            />
            <FormKit type="number" name="quantity" label="Quantidade" placeholder="1" validation="required" />
          </FormKit>
        </FormKit>
      </div>
    </SheetContent>
  </Sheet>
</template>
