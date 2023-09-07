<script setup lang="ts">
import type { SignIn } from "@/api/types";
import { useAuthStore } from "@/stores";

const authStore = useAuthStore();

async function submitHandler(data: SignIn) {
  try {
    await authStore.login(data.email, data.password);
  } catch (error) {
    // TODO: Improve
    alert("Credencias invalidas");
  }
}
</script>

<template>
  <div class="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
    <div class="sm:mx-auto sm:w-full sm:max-w-sm">
      <img class="mx-auto h-24 w-auto" src="/logo.png" alt="Opuspac" />
      <h2 class="mt-6 text-center text-display-sm font-bold leading-9 tracking-tight text-gray-900">
        Acesse sua conta
      </h2>
      <p class="mt-3 text-center text-md text-gray-600">Bem-vindo de volta!</p>
    </div>

    <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-sm">
      <FormKit type="form" @submit="submitHandler" submit-label="Entrar">
        <FormKit
          type="email"
          name="email"
          label="Email"
          validation="required"
          placeholder="exemplo@dominio.com"
        />
        <FormKit
          type="password"
          name="password"
          label="Senha"
          validation="required"
          placeholder="************"
        />
      </FormKit>

      <p class="mt-8 text-center text-sm text-gray-500">
        Não tem uma conta?
        {{ " " }}
        <RouterLink
          :to="{ name: 'sign-up' }"
          class="font-semibold text-primary-700 transition-colors hover:text-primary-900"
        >
          Cadastre-se
        </RouterLink>
      </p>
    </div>
  </div>
</template>
