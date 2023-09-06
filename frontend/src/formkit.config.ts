import { pt } from "@formkit/i18n";
import type { DefaultConfigOptions } from "@formkit/vue";
import { generateClasses } from "@formkit/themes";
import { genesisIcons } from "@formkit/icons";
import { createProPlugin, inputs } from "@formkit/pro";
import myTailwindTheme from "@/formkit.theme";

const proPlugin = createProPlugin("fk-6ff4101fe0", inputs);

const config: DefaultConfigOptions = {
  locales: { pt },
  locale: "pt",
  icons: {
    ...genesisIcons,
  },
  config: {
    classes: generateClasses(myTailwindTheme),
  },
  plugins: [proPlugin],
};

export default config;
