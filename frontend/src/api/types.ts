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
