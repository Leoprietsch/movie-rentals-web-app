import "../styles/globals.css";
import type { AppProps } from "next/app";
import Layout from "../components/Layout";
import { ConfigProvider } from "antd";
import ptBr from "antd/lib/locale/pt_BR";

function App({ Component, pageProps }: AppProps) {
  return (
    <ConfigProvider locale={ptBr}>
      <Layout child={<Component {...pageProps} />} />
    </ConfigProvider>
  );
}

export default App;
