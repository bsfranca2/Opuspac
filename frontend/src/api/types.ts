export type User = {
  name: string;
  email: string;
};

export type SignIn = {
  email: string;
  password: string;
};

export type SignUp = User & { password: string };

export type Token = {
  token: string;
};

export type PrinterMetrics = {
  printerAgentsConnected: number;
  printJobsWaiting: number;
  printJobsError: number;
};

export type PrinterAgent = {
  id: string;
  name: string;
  ip: string;
  printerModel: string;
  // TODO: Alterar para o backend nao export client id
  isConnected: boolean;
  lastActiveConnectionDate: string | null;
};

export type Patient = {
  id: string;
  name: string;
  bed: string;
};

export type Prescription = {
  id: string;
  code: string;
  attendantId: string;
  time: string;
  patient: {
    name: string;
    bed: string;
  };
};

export type CreatePrescription = {
  patientId: string;
  code: string;
  attendantId: string;
  time: string;
  medicines: Array<{
    name: string;
    quantity: number;
    administrationInstructions: string;
  }>;
};

export type CreatePrintJob = {
  prescriptionId: string;
};
