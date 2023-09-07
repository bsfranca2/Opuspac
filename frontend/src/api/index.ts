import axios, { AxiosError } from "axios";
import type {
  PrinterMetrics,
  PrinterAgent,
  Patient,
  CreatePrescription,
  Prescription,
  CreatePrintJob,
  SignIn,
  SignUp,
  User,
  Token,
  CreatePatient,
} from "./types";
import { useAuthStore } from "@/stores";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? "http://localhost:5091/",
});
export const setAuthorization = (token: string | null) => {
  if (token) {
    api.defaults.headers.common["authorization"] = `Bearer ${token}`;
  } else {
    delete api.defaults.headers.common["authorization"];
  }
};
api.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error: AxiosError) {
    const authStore = useAuthStore();
    if ([401, 403].includes(error.response?.status ?? 200) && authStore.isAuthenticated) {
      authStore.logout();
    }
    return Promise.reject(error);
  }
);

export const postSignIn = (data: SignIn) => api.post<Token>("/sign-in", data).then((res) => res.data);

export const postSignUp = (data: SignUp) => api.post<User>("/sign-up", data).then((res) => res.data);

export const getMe = () => api.get<User>("/me").then((res) => res.data);

export const getPrinterMetrics = () => api.get<PrinterMetrics>("/printer-metrics").then((res) => res.data);

export const getPrinterAgents = () => api.get<PrinterAgent[]>("/printer-agents").then((res) => res.data);

export const getPatients = () => api.get<Patient[]>("/patients").then((res) => res.data);

export const postPatients = (data: CreatePatient) => api.post("/patients", data).then((res) => res.data);

export const getPrescriptions = () => api.get<Prescription[]>("/prescriptions").then((res) => res.data);

export const postPrescriptions = (data: CreatePrescription) =>
  api.post("/prescriptions", data).then((res) => res.data);

export const postPrintJob = (data: CreatePrintJob) => api.post("/print-jobs", data).then((res) => res.data);
