import Title from "antd/lib/typography/Title";
import React from "react";
import { Form, Input, Button, DatePicker } from "antd";
import { Moment } from "moment";

function CadastrarCliente() {
  const onFinish = (values: any) => {
    const dataNascimento = values.dataNascimento as Moment;
  };

  return (
    <>
      <Title>Cadastro de cliente</Title>
      <Form
        wrapperCol={{ span: 6 }}
        layout="vertical"
        size={"middle"}
        onFinish={onFinish}
      >
        <Form.Item required name="nome" label="Nome">
          <Input />
        </Form.Item>
        <Form.Item name="cpf" required label="CPF">
          <Input />
        </Form.Item>
        <Form.Item required name="dataNascimento" label="Data de Nascimento">
          <DatePicker format={"DD/MM/yyyy"} />
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit">
            Salvar
          </Button>
        </Form.Item>
      </Form>
    </>
  );
}

export default CadastrarCliente;
