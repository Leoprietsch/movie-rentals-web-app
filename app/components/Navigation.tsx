import { Menu } from "antd";
import {
  HomeOutlined,
  UserOutlined,
  VideoCameraOutlined,
  InteractionOutlined,
} from "@ant-design/icons";
import { useRouter } from "next/router";
import { useState } from "react";

function Navigation() {
  const router = useRouter();

  const [current, setCurrent] = useState("/");

  const handleClick = (e: any) => {
    console.log(e);
    setCurrent(e.key);
    router.push(e.key);
  };

  return (
    <Menu onClick={handleClick} selectedKeys={[current]} mode="horizontal">
      <Menu.Item key="/" icon={<HomeOutlined />}>
        Página Inicial
      </Menu.Item>
      <Menu.Item key="/filmes" icon={<VideoCameraOutlined />}>
        Filmes
      </Menu.Item>
      <Menu.Item key="/clientes" icon={<UserOutlined />}>
        Clientes
      </Menu.Item>
      <Menu.Item key="/locacoes" icon={<InteractionOutlined />}>
        Locações
      </Menu.Item>
    </Menu>
  );
}

export default Navigation;
