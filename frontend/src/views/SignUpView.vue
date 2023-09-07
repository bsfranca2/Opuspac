<script setup lang="ts">
import { postSignUp } from "@/api";
import type { SignUp } from "@/api/types";
import { useAuthStore } from "@/stores";

const authStore = useAuthStore();

async function submitHandler(data: SignUp) {
  try {
    await postSignUp(data);
    authStore.login(data.email, data.password);
  } catch (error) {
    alert("Falha na criação de conta");
  }
}
</script>

<template>
  <div class="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
    <div class="sm:mx-auto sm:w-full sm:max-w-sm">
      <img class="mx-auto h-24 w-auto" src="/logo.png" alt="Opuspac" />
      <h2 class="mt-6 text-center text-display-sm font-bold leading-9 tracking-tight text-gray-900">
        Crie uma conta
      </h2>
      <p class="mt-3 text-center text-md text-gray-600">Registre-se e comece</p>
    </div>

    <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-sm">
      <FormKit type="form" @submit="submitHandler" submit-label="Criar conta">
        <FormKit type="text" name="name" label="Nome" validation="required" placeholder="Digite seu nome" />
        <FormKit
          type="email"
          name="email"
          label="Email"
          validation="required"
          placeholder="Digite seu email"
        />
        <FormKit
          type="password"
          name="password"
          label="Senha"
          minlength="8"
          validation="required|length:8"
          placeholder="Criar uma senha"
          help="Deve ter pelo menos 8 caracteres"
        />
      </FormKit>

      <p class="mt-8 text-center text-sm text-gray-500">
        Já tem uma conta?
        {{ " " }}
        <RouterLink
          :to="{ name: 'sign-in' }"
          class="font-semibold text-primary-700 transition-colors hover:text-primary-900"
        >
          Faça login
        </RouterLink>
      </p>
    </div>
  </div>
</template>
