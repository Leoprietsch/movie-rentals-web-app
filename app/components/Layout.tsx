import { Layout as AntLayout, Menu } from "antd";
import {
  HomeOutlined,
  UserOutlined,
  VideoCameraOutlined,
  InteractionOutlined,
} from "@ant-design/icons";
import React, { useState } from "react";
import { useRouter } from "next/router";

const { Header, Content, Footer, Sider } = AntLayout;

function Layout(props: { child: React.ReactNode }) {
  const { child } = props;

  const router = useRouter();

  const [current, setCurrent] = useState("/");

  const handleClick = (e: any) => {
    console.log(e);
    setCurrent(e.key);
    router.push(e.key);
  };

  return (
    <AntLayout>
      <Sider
        breakpoint="lg"
        collapsedWidth="0"
        onBreakpoint={(broken) => {
          console.log(broken);
        }}
        onCollapse={(collapsed, type) => {
          console.log(collapsed, type);
        }}
      >
        <Menu
          theme="dark"
          onClick={handleClick}
          mode="inline"
          defaultSelectedKeys={[current]}
        >
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
      </Sider>
      <AntLayout>
        <Content style={{ margin: "24px 16px 0" }}>{child}</Content>
        <Footer style={{ textAlign: "center" }}>
          Movie Rentals ©2022 Created by Leoprietsch
        </Footer>
      </AntLayout>
    </AntLayout>
  );
}

export default Layout;
