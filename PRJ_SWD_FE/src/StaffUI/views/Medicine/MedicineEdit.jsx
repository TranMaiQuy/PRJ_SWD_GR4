import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const MedicineEdit = () => {
  const { id } = useParams();
  const [form, setForm] = useState({
    name: "",
    quantity: 0,
    price: 0,
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/medicine/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Không thể lấy dữ liệu thuốc");
        return res.json();
      })
      .then((data) => {
        setForm(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Lỗi khi tải thuốc:", err);
        alert("Lỗi khi tải dữ liệu thuốc");
        setLoading(false);
      });
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: name === "price" || name === "quantity" ? Number(value) : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    fetch(`https://localhost:7012/api/medicine/edit/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Không thể cập nhật thuốc");
        alert("Cập nhật thuốc thành công!");
        window.location.href = "/medicine";
      })
      .catch((err) => {
        console.error("Lỗi khi cập nhật thuốc:", err);
        alert("Lỗi khi cập nhật thuốc");
      });
  };

  if (loading) return <p>Đang tải dữ liệu...</p>;

  return (
    <div style={{ maxWidth: "500px", margin: "0 auto", padding: "20px" }}>
      <h2>Chỉnh sửa thuốc #{id}</h2>
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

        <button type="submit">Cập nhật</button>{" "}
        <button type="button" onClick={() => window.location.href = "/medicine"}>Huỷ</button>
      </form>
    </div>
  );
};

export default MedicineEdit;
