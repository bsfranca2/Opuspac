<script setup lang="ts">
import { Button } from "@/components/ui/button";
import IconPlus from "~icons/op/plus";
</script>

<template>
  <div className="flex items-start justify-between">
    <h2 className="text-display-sm font-semibold">Prescrições</h2>
    <div>
      <!-- Actions -->
      <Button>
        <IconPlus class="mr-2 h-5 w-5" />
        Adicionar
      </Button>
    </div>
  </div>
  <div>
    <!-- Content -->
  </div>
</template>
