<script setup lang="ts">
import { useQueryClient } from "@tanstack/vue-query";
import { ref } from "vue";
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetTrigger } from "@/components/ui/sheet";
import IconPlus from "~icons/op/plus";
import { Button } from "@/components/ui/button";
import { postPatients } from "@/api";
import type { CreatePatient } from "@/api/types";

const open = ref(false);

const queryClient = useQueryClient();

async function submitHandler(data: CreatePatient) {
  await postPatients(data);
  queryClient.invalidateQueries(["patients"]);
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
        <SheetTitle>Adicionar Paciente</SheetTitle>
      </SheetHeader>
      <div class="mt-4">
        <FormKit type="form" @submit="submitHandler" submit-label="Salvar">
          <FormKit type="text" name="name" label="Nome" validation="required" placeholder="Digite o nome" />
          <FormKit
            type="text"
            name="bed"
            label="Setor/Leito"
            validation="required"
            placeholder="Digite o setor/leito"
          />
        </FormKit>
      </div>
    </SheetContent>
  </Sheet>
</template>
