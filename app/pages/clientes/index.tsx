import { Button, Space, Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import { UserAddOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import Cliente from "../../entities/Cliente";
import { useRouter } from "next/router";
import { getAll } from "../../apiClients/clientesClient";

function Clientes() {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const router = useRouter();

  useEffect(() => {
    getAll()
      .then((response: any) => {
        setClientes(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

  const colunas: ColumnsType<Cliente> = [
    {
      title: "Nome",
      dataIndex: "nome",
      key: "nome",
    },
    {
      title: "CPF",
      dataIndex: "cpf",
      key: "cpf",
    },
    {
      title: "Data de Nascimento",
      dataIndex: "dataNascimento",
      key: "dataNascimento",
      render: (value, cliente: Cliente) => {
        return new Date(cliente?.dataNascimento).toLocaleString("pt-br", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
        });
      },
    },
    {
      title: "Ações",
      dataIndex: "acoes",
      key: "acoes",
      render: (value, cliente: Cliente) => {
        return (
          <Space size="middle">
            <Button href={`/clientes/editar/${cliente.id}`}>Editar</Button>
            <Button danger>Excluir</Button>
          </Space>
        );
      },
    },
  ];

  return (
    <>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Title>Clientes</Title>
        <Button
          type="primary"
          size="large"
          icon={<UserAddOutlined />}
          onClick={() => router.push("/clientes/cadastrar")}
        >
          Cadastrar cliente
        </Button>
      </div>

      <Table columns={colunas} dataSource={clientes} />
    </>
  );
}

export default Clientes;
