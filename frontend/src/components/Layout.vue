<script setup lang="ts">
import Sidebar from "./Sidebar.vue";
</script>

<template>
  <Sidebar />
  <main class="py-10 lg:pl-72">
    <div class="px-4 sm:px-6 lg:px-8">
      <slot />
    </div>
  </main>
</template>
