import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const PrescriptionEdit = () => {
  const { id } = useParams();
  const [form, setForm] = useState({
    prescriptionId: 0,
    examinationId: 0,
    doctorId: 0,
    customerId: 0,
    medicineId: 0,
    dosage: "",
    note: "",
    totalCost: 0,
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/prescription/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Không thể lấy dữ liệu toa thuốc");
        return res.json();
      })
      .then((data) => {
        setForm({
          prescriptionId: parseInt(id),
          examinationId: data.examinationId,
          doctorId: data.doctorId,
          customerId: data.customerId,
          medicineId: data.medicineId,
          dosage: data.dosage,
          note: data.note,
          totalCost: data.totalCost,
        });
        setLoading(false);
      })
      .catch((err) => {
        console.error("Lỗi khi tải toa thuốc:", err);
        alert("Lỗi khi tải dữ liệu toa thuốc");
        setLoading(false);
      });
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: ["examinationId", "doctorId", "customerId", "medicineId", "totalCost"].includes(name)
        ? Number(value)
        : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (form.totalCost <= 0) {
      alert("Tổng chi phí phải lớn hơn 0");
      return;
    }

    const payload = {
      prescriptionId: form.prescriptionId,
      examinationId: form.examinationId,
      doctorId: form.doctorId,
      customerId: form.customerId,
      medicineId: form.medicineId,
      dosage: form.dosage,
      note: form.note,
      totalCost: form.totalCost,
    };

    console.log("Dữ liệu gửi lên:", payload);

    fetch(`https://localhost:7012/api/prescription/edit/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Không thể cập nhật toa thuốc");
        alert("Cập nhật toa thuốc thành công!");
        window.location.href = "/prescription";
      })
      .catch((err) => {
        console.error("Lỗi khi cập nhật toa thuốc:", err);
        alert("Lỗi khi cập nhật toa thuốc");
      });
  };

  if (loading) return <p>Đang tải dữ liệu toa thuốc...</p>;

  return (
    <div style={{ maxWidth: "600px", margin: "0 auto", padding: "20px" }}>
      <h2>Chỉnh sửa Toa thuốc #{id}</h2>
      <form onSubmit={handleSubmit}>
        <label>Examination ID:</label><br />
        <input
          type="number"
          name="examinationId"
          value={form.examinationId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Doctor ID:</label><br />
        <input
          type="number"
          name="doctorId"
          value={form.doctorId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Customer ID:</label><br />
        <input
          type="number"
          name="customerId"
          value={form.customerId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Medicine ID:</label><br />
        <input
          type="number"
          name="medicineId"
          value={form.medicineId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Liều dùng (Dosage):</label><br />
        <input
          type="text"
          name="dosage"
          value={form.dosage}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Ghi chú:</label><br />
        <input
          type="text"
          name="note"
          value={form.note}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Tổng chi phí:</label><br />
        <input
          type="number"
          name="totalCost"
          value={form.totalCost}
          onChange={handleChange}
          required
        /><br /><br />

        <button type="submit">Cập nhật</button>{" "}
        <button type="button" onClick={() => window.location.href = "/prescription"}>Huỷ</button>
      </form>
    </div>
  );
};

export default PrescriptionEdit;
