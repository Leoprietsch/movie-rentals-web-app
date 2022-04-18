import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";
import { Form, Input, Button, DatePicker } from "antd";
import Cliente from "../../../entities/Cliente";
import { useRouter } from "next/router";
import moment, { Moment } from "moment";

function EditarCliente() {
  const [form] = Form.useForm();
  const [cliente, setCliente] = useState<Cliente>();
  const router = useRouter();
  const { query } = router;

  const createDate = () => {
    let date = new Date();
    date.setFullYear(18);
    date.setMonth(8);
    date.setFullYear(1997);
    console.log(date);
    return date;
  };

  useEffect(() => {
    setCliente({
      id: Number(query.id),
      nome: "Leonardo Oliveira",
      cpf: "85953547072",
      dataNascimento: createDate(),
    });
  }, [form]);

  useEffect(() => {
    form.setFieldsValue({
      nome: cliente?.nome,
      cpf: cliente?.cpf,
      dataNascimento: moment(cliente?.dataNascimento),
    });
  }, [cliente]);

  const onFinish = (values: any) => {
    const dataNascimento = values.dataNascimento as Moment;
    console.log(dataNascimento.toDate());
  };

  return (
    <>
      <Title>Edição de cliente</Title>
      <Form
        form={form}
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
          <Button htmlType="submit">Salvar</Button>
        </Form.Item>
      </Form>
    </>
  );
}

export default EditarCliente;
