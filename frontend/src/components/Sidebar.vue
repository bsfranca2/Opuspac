<script setup lang="ts">
import { ref } from "vue";
import { Dialog, DialogPanel, TransitionChild, TransitionRoot } from "@headlessui/vue";
import IconHome from "~icons/op/home";
import IconPrescription from "~icons/op/prescription";
import IconPrinter from "~icons/op/printer";
import IconMenu from "~icons/op/menu";
import IconX from "~icons/op/x-close";

const navigation = [
  { name: "Início", href: "/", icon: IconHome },
  { name: "Prescrições", href: "/prescriptions", icon: IconPrescription },
  { name: "Impressoras", href: "/printers", icon: IconPrinter },
];

const sidebarOpen = ref(false);
</script>

<template>
  <TransitionRoot as="template" :show="sidebarOpen">
    <Dialog as="div" class="relative z-50 lg:hidden" @close="sidebarOpen = false">
      <TransitionChild
        as="template"
        enter="transition-opacity ease-linear duration-300"
        enter-from="opacity-0"
        enter-to="opacity-100"
        leave="transition-opacity ease-linear duration-300"
        leave-from="opacity-100"
        leave-to="opacity-0"
      >
        <div class="fixed inset-0 bg-gray-900/80" />
      </TransitionChild>

      <div class="fixed inset-0 flex">
        <TransitionChild
          as="template"
          enter="transition ease-in-out duration-300 transform"
          enter-from="-translate-x-full"
          enter-to="translate-x-0"
          leave="transition ease-in-out duration-300 transform"
          leave-from="translate-x-0"
          leave-to="-translate-x-full"
        >
          <DialogPanel class="relative mr-16 flex w-full max-w-xs flex-1">
            <TransitionChild
              as="template"
              enter="ease-in-out duration-300"
              enter-from="opacity-0"
              enter-to="opacity-100"
              leave="ease-in-out duration-300"
              leave-from="opacity-100"
              leave-to="opacity-0"
            >
              <div class="absolute left-full top-0 flex w-16 justify-center pt-5">
                <button type="button" class="-m-2.5 p-2.5" @click="sidebarOpen = false">
                  <span class="sr-only">Fechar menu</span>
                  <IconX class="h-6 w-6 text-white" aria-hidden="true" />
                </button>
              </div>
            </TransitionChild>
            <div class="flex grow flex-col gap-y-5 overflow-y-auto bg-white px-6 pb-2">
              <div class="flex h-24 shrink-0 items-center">
                <img class="h-16 w-auto" src="/logo.png" alt="Opuspac" />
              </div>
              <nav class="flex flex-1 flex-col">
                <ul role="list" class="-mx-2 space-y-1">
                  <li v-for="item in navigation" :key="item.name">
                    <RouterLink :to="item.href" class="menu-item" exact-active-class="current">
                      <component :is="item.icon" class="h-6 w-6 shrink-0" aria-hidden="true" />
                      {{ item.name }}
                    </RouterLink>
                  </li>
                </ul>
              </nav>
            </div>
          </DialogPanel>
        </TransitionChild>
      </div>
    </Dialog>
  </TransitionRoot>

  <div class="hidden lg:fixed lg:inset-y-0 lg:z-50 lg:flex lg:w-72 lg:flex-col">
    <div class="flex grow flex-col gap-y-6 overflow-y-auto border-r border-gray-200 px-4">
      <div class="mt-8 flex shrink-0 items-center">
        <img class="h-16 w-auto" src="/logo.png" alt="Opuspac" />
        <h1 class="ml-1 text-display-xs font-bold">Opuspac</h1>
      </div>
      <nav class="flex flex-1 flex-col">
        <ul class="flex flex-1 flex-col">
          <li>
            <ul class="-mx-2 space-y-1">
              <li v-for="item in navigation" :key="item.name">
                <RouterLink :to="item.href" class="menu-item" exact-active-class="current">
                  <component :is="item.icon" aria-hidden="true" />
                  {{ item.name }}
                </RouterLink>
              </li>
            </ul>
          </li>
          <li class="-mx-2 mt-auto pb-8">
            <a href="#" class="menu-item">
              <IconHome aria-hidden="true" />
              Sair
            </a>
          </li>
        </ul>
      </nav>
    </div>
  </div>

  <div class="sticky top-0 z-40 flex items-center gap-x-6 bg-white px-4 py-4 shadow-sm sm:px-6 lg:hidden">
    <button type="button" class="-m-2.5 p-2.5 text-gray-700 lg:hidden" @click="sidebarOpen = true">
      <span class="sr-only">Abrir menu</span>
      <IconMenu class="h-6 w-6" aria-hidden="true" />
    </button>
    <div class="flex-1 text-sm font-semibold leading-6 text-gray-900">Dashboard</div>
    <a href="#">
      <span class="sr-only">Seu perfil</span>
      <img
        class="h-8 w-8 rounded-full bg-gray-50"
        src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
        alt=""
      />
    </a>
  </div>
</template>
