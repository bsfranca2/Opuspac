import { createApp } from "vue";
import { VueQueryPlugin } from "@tanstack/vue-query";
import { plugin, defaultConfig } from "@formkit/vue";
import { createPinia } from "pinia";

import App from "@/App.vue";
import { router } from "@/views";
import config from "@/formkit.config";
import "@/assets/main.css";
import { initAuth } from "@/stores";

const pinia = createPinia();

const app = createApp(App);
app.use(pinia);
app.use(plugin, defaultConfig(config));
app.use(VueQueryPlugin);
app.use(router);

initAuth();

app.mount("#app");
