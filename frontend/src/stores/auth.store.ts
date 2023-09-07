import { defineStore } from "pinia";
import { getMe, postSignIn, setAuthorization } from "@/api";
import type { User } from "@/api/types";
import { generateAvatarName } from "@/lib/avatar";
import { getToken, setToken } from "@/lib/token";

export type AuthState = {
  user: User & { avatarName: string };
  token: string | null;
  returnUrl: string | null;
  isAuthenticated: boolean;
  isLoading: boolean;
};

const stateFactory = (): AuthState => ({
  user: null as unknown as AuthState["user"],
  token: getToken(),
  returnUrl: null,
  isAuthenticated: false,
  isLoading: true,
});

export const useAuthStore = defineStore({
  id: "auth",
  state: stateFactory,
  actions: {
    async login(email: string, password: string) {
      const { token } = await postSignIn({ email, password });
      setToken(token);
      const returnTo = ["/sign-in", "/sign-up"].includes(`${this.returnUrl}`) ? "/" : this.returnUrl;
      window.location.href = returnTo || "/";
    },
    async me() {
      try {
        const me = await getMe();
        this.user = { ...me, avatarName: generateAvatarName(me.name) };
        this.isAuthenticated = true;
      } catch (error) {
        this.isAuthenticated = false;
      }
      this.isLoading = false;
    },
    logout() {
      setToken("");
      window.location.href = "/sign-in";
    },
  },
});

export const initAuth = () => {
  if (getToken()) {
    initAuthState = (async () => {
      const auth = useAuthStore();
      setAuthorization(auth.token);
      try {
        await auth.me();
      } catch (error) {
        setAuthorization(null);
      }
    })();
  }
};

// eslint-disable-next-line prefer-const
let initAuthState: Promise<void> | null = null;
export const getInitAuthState = () => initAuthState;
