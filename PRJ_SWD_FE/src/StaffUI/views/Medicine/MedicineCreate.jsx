import React, { useState } from "react";

const MedicineCreate = () => {
  const [form, setForm] = useState({
    name: "",
    quantity: 0,
    price: 0,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: name === "quantity" || name === "price" ? Number(value) : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    fetch("https://localhost:7012/api/medicine/create", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Không thể tạo thuốc");
        alert("Thêm thuốc thành công!");
        window.location.href = "/medicine";
      })
      .catch((err) => {
        console.error("Lỗi khi tạo thuốc:", err);
        alert("Lỗi khi thêm thuốc");
      });
  };

  return (
    <div style={{ maxWidth: "500px", margin: "0 auto", padding: "20px" }}>
      <h2>Thêm thuốc mới</h2>
      <form onSubmit={handleSubmit}>
        <label>Tên thuốc:</label><br />
        <input
          type="text"
          name="name"
          value={form.name}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Số lượng:</label><br />
        <input
          type="number"
          name="quantity"
          value={form.quantity}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Giá:</label><br />
        <input
          type="number"
          name="price"
          value={form.price}
          onChange={handleChange}
          required
        /><br /><br />

        <button type="submit">Tạo thuốc</button>{" "}
        <button type="button" onClick={() => window.location.href = "/medicine"}>Huỷ</button>
      </form>
    </div>
  );
};

export default MedicineCreate;
