import { createRouter, createWebHashHistory } from "vue-router";
// import HomeView from "@/views/HomeView.vue";
import PrescriptionView from "@/views/PrescriptionView.vue";
import PrinterView from "@/views/PrinterView.vue";

const routes = [
  // {
  //   path: "/",
  //   name: "home",
  //   component: HomeView,
  // },
  {
    path: "/",
    name: "prescriptions",
    component: PrescriptionView,
  },
  {
    path: "/printers",
    name: "printers",
    component: PrinterView,
  },
];

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
});
