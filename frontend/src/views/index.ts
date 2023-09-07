import BlankLayout from "@/components/BlankLayout.vue";
import Layout from "@/components/Layout.vue";
import { getInitAuthState, useAuthStore } from "@/stores";
import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "prescriptions",
    component: () => import(/* webpackChunkName: "prescriptions" */ "@/views/PrescriptionView.vue"),
    meta: { layout: Layout },
  },
  {
    path: "/printers",
    name: "printers",
    component: () => import(/* webpackChunkName: "printers" */ "@/views/PrinterView.vue"),
    meta: { layout: Layout },
  },
  {
    path: "/sign-in",
    name: "sign-in",
    component: () => import(/* webpackChunkName: "sign-in" */ "@/views/SignInView.vue"),
    meta: { layout: BlankLayout },
  },
  {
    path: "/sign-up",
    name: "sign-up",
    component: () => import(/* webpackChunkName: "sign-up" */ "@/views/SignUpView.vue"),
    meta: { layout: BlankLayout },
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach(async (to) => {
  const publicPages = ["/sign-in", "/sign-up"];
  const authRequired = !publicPages.includes(to.path);
  const auth = useAuthStore();

  if (auth.isLoading) {
    const initAuthState = getInitAuthState();
    if (initAuthState) await initAuthState;
  }

  if (authRequired && !auth.isAuthenticated) {
    auth.returnUrl = to.fullPath;
    return { name: "sign-in" };
  }
});

router.afterEach((to) => {
  const bodyElement = document.querySelector("body");
  const pageId = to.name?.toString();
  if (bodyElement && pageId && pageId.startsWith("sign")) {
    bodyElement.setAttribute("data-sign-page", "true");
  }
});
