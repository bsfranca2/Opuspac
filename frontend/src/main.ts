import { createApp } from "vue";
import { VueQueryPlugin } from "@tanstack/vue-query";
import { plugin, defaultConfig } from "@formkit/vue";
import App from "@/App.vue";
import { router } from "@/router";
import config from "@/formkit.config";
import "@/assets/main.css";

createApp(App).use(VueQueryPlugin).use(router).use(plugin, defaultConfig(config)).mount("#app");
