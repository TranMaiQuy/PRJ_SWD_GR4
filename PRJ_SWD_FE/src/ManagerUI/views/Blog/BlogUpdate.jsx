import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './CreateBlog.css';

function UpdateBlog() {
  const { id } = useParams();

  const [formData, setFormData] = useState({
    blogId: id,
    title: '',
    content: '',
    description: '',
    createdDate: '',
    personId: '',
    categoryId: ''
  });

  const [selectedFile, setSelectedFile] = useState(null);
  const [previewImage, setPreviewImage] = useState('');
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/blog/${id}`)
      .then(res => {
        if (!res.ok) throw new Error('Không thể lấy dữ liệu');
        return res.json();
      })
      .then(data => {
        setFormData({
          blogId: data.blogId,
          title: data.title,
          content: data.content,
          description: data.description,
          createdDate: data.createdDate.split('T')[0],
          personId: data.personId,
          categoryId: data.categoryId
        });
        if (data.image) {
          setPreviewImage(`https://localhost:7012/images/${data.image}`);
        }
        setLoading(false);
      })
      .catch(err => {
        console.error(err);
        alert('Lỗi khi tải blog');
      });
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    setSelectedFile(file);
    if (file) {
      setPreviewImage(URL.createObjectURL(file));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const form = new FormData();
    form.append('blogId', formData.blogId);
    form.append('title', formData.title);
    form.append('content', formData.content);
    form.append('description', formData.description);
    form.append('createdDate', formData.createdDate);
    form.append('personId', formData.personId);
    form.append('categoryId', formData.categoryId);
    if (selectedFile) {
      form.append('image', selectedFile); // gửi file
    }

    try {
      const response = await fetch(`https://localhost:7012/api/blog/${id}`, {
        method: 'PUT',
        body: form // KHÔNG set Content-Type, browser sẽ tự gán đúng kiểu multipart/form-data
      });

      if (response.ok) {
        alert('Cập nhật thành công!');
      } else {
        alert('Lỗi cập nhật. Mã lỗi: ' + response.status);
      }
    } catch (error) {
      console.error('Lỗi khi gửi yêu cầu cập nhật:', error);
      alert('Lỗi hệ thống khi cập nhật.');
    }
  };

  if (loading) return <p>Đang tải dữ liệu...</p>;

  return (
    <div className="update-blog-container">
      <h2>Cập nhật Blog</h2>
      <form onSubmit={handleSubmit}>
        <label>Tiêu đề:</label>
        <input type="text" name="title" value={formData.title} onChange={handleChange} />

        <label>Nội dung:</label>
        <textarea name="content" value={formData.content} onChange={handleChange}></textarea>

        <label>Mô tả:</label>
        <input type="text" name="description" value={formData.description} onChange={handleChange} />

        <label>Ảnh:</label>
        <input type="file" name="image" onChange={handleFileChange} />
        {previewImage && (
          <div className="image-preview">
            <img src={previewImage} alt="Ảnh xem trước" style={{ maxWidth: '100%', maxHeight: '200px' }} />
          </div>
        )}

        <label>Ngày tạo:</label>
        <input
          type="date"
          name="createdDate"
          value={formData.createdDate}
          onChange={handleChange}
        />

        <label>Người viết (PersonId):</label>
        <input type="number" name="personId" value={formData.personId} onChange={handleChange} />

        <label>Danh mục (CategoryId):</label>
        <input type="number" name="categoryId" value={formData.categoryId} onChange={handleChange} />

        <button type="submit">Cập nhật</button>
      </form>
    </div>
  );
}

export default UpdateBlog;
