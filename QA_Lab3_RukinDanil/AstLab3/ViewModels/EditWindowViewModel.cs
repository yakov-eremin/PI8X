using AstLab3.Models.Services.Interfaces;
using AstLab3.ViewModels.Base;
using System;
using System.Collections.Generic;
using AstLab3.Models.Schedules;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using AstLab3.Infrastructure.Commands;
using AstLab3.Models.Services.Data;

namespace AstLab3.ViewModels
{
	/// <summary>
	/// Модель представления окна <see cref="Views.Windows.EditWindow"/>
	/// </summary>
	/// <inheritdoc/>
	public class EditWindowViewModel : ClosableViewModel
	{
		private EditingWindowData _editingWindowData;

		private Dictionary<int, List<Work>> _adjacencyList;

		private readonly Dictionary<string, object> _buffer = new Dictionary<string, object>();

		protected bool SetValue(object value, [CallerMemberName] string propertyName = null)
		{
			if (_buffer.TryGetValue(propertyName, out var oldValue) && Equals(value, oldValue))
				return false;

			_buffer[propertyName] = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		protected virtual T GetValue<T>(T oldValue, [CallerMemberName] string propertyName = null)
		{
			if (_buffer.TryGetValue(propertyName, out object value))
				return (T)value;
			return oldValue;
		}
		/// <summary>
		/// Режим, в котором будет работать модель и представление.
		/// </summary>
		public EditingMode EditingMode { get; set; } = EditingMode.StartVertexMode;

		private ILogger _logger;
		private NetworkSchedule _networkSchedule;
		/// <summary>
		/// Создает модель представления <see cref="EditWindowViewModel"/> окна <see cref="Views.Windows.EditWindow"/>
		/// для редактирования структуры сетевого графика.
		/// </summary>
		/// <param name="editingWindowData">Данные, необходимые для редактирования</param>
		/// <param name="networkSchedule">Сетевой график</param>
		/// <param name="logger">Логгер для регистрации процесса редактирования</param>
		public EditWindowViewModel(EditingWindowData editingWindowData, NetworkSchedule networkSchedule, ILogger logger)
		{
			_networkSchedule = networkSchedule;
			_logger = logger;
			_editingWindowData = editingWindowData;
			if (editingWindowData.PreferedAction == PreferedAction.AddFakeVertex)
				AddingFakeVertexIsNecessary = true;
			else if (editingWindowData.PreferedAction == PreferedAction.DeleteVertices)
				DeletingVerticesIsNecessary = true;
			else
				DeletingEdgesIsNecessary = true;
			EditingMode = editingWindowData.EditingMode;
			MeaningLine = editingWindowData.MeaningLine;
			PrepareVerticesDeleting();
			PrepareEdgesDeleting();
			ChoiceOfActionCommand = new LambdaCommand(OnChoiceOfActionCommandExecuted,
				CanChoiceOfActionCommandExecute);
			AddFakeVertexCommand = new LambdaCommand(OnAddFakeVertexCommandExecuted,
				CanAddFakeVertexCommandExecute);
			DeleteVerticesCommand = new LambdaCommand(OnDeleteVerticesCommandExecuted,
				CanDeleteVerticesCommandExecute);
			DeleteEdgesCommand = new LambdaCommand(OnDeleteEdgesCommandExecuted,
				CanDeleteEdgesCommandExecute);
			AcceptCommand = new LambdaCommand(OnAcceptCommandExecuted,
				CanAcceptCommandExecute);
		}

		#region Properties

		private string _title = "Редактирование вершин";
		/// <summary>
		/// Текст заголовка окна
		/// </summary>
		public string Title { get => _title; set => Set(ref _title, value); }

		private string _status = "Редактирование вершин";
		/// <summary>
		/// Возвращает или устанавливает текст статус-строки окна
		/// </summary>
		public string Status { get => _status; set => Set(ref _status, value); }

		private string _meaningLine = "Редактирование вершин";
		/// <summary>
		/// Устанавливает или задает текст, сообщающий о режиме работы окна
		/// </summary>
		public string MeaningLine { get => _meaningLine; set => Set(ref _meaningLine, value); }

		private string _fakeVertexIndex;
		/// <summary>
		/// Устанавливает или задает индекс искусственного события, которое будет создано в сетевом графике.
		/// </summary>
		public string FakeVertexIndex
		{
			get => _fakeVertexIndex;
			set => Set(ref _fakeVertexIndex, value);
		}

		private string _indexesToConnectWithFakeVertex;
		/// <summary>
		/// Устанавливает или задает перечисление индексов событий, с которыми следует соединить вновь созданное событие
		/// </summary>
		public string IndexesToConnectWithFakeVertex
		{
			get => _indexesToConnectWithFakeVertex;
			set => Set(ref _indexesToConnectWithFakeVertex, value);
		}

		private bool _addingFakeVertexIsNecessary = true;
		/// <summary>
		/// Устанавливает или задает необходимость создания искусственного события. Является отображением для интерфейса.
		/// </summary>
		public bool AddingFakeVertexIsNecessary
		{
			get => _addingFakeVertexIsNecessary;
			set => Set(ref _addingFakeVertexIsNecessary, value);
		}

		private bool _deletingVerticesIsNecessary = false;
		private List<Vertex> _deletedVertices = new List<Vertex>();
		/// <summary>
		/// Устанавливает или задает необходимость удаления событий из графика. Является отображением для интерфейса.
		/// </summary>
		public bool DeletingVerticesIsNecessary
		{
			get => _deletingVerticesIsNecessary;
			set => Set(ref _deletingVerticesIsNecessary, value);
		}

		private bool _deletingEdgesIsNecessary = false;
		/// <summary>
		/// Устанавливает или задает необходимость удаления работ из графика. Является отображением для интерфейса.
		/// </summary>
		public bool DeletingEdgesIsNecessary
		{
			get => _deletingEdgesIsNecessary;
			set => Set(ref _deletingEdgesIsNecessary, value);
		}

		private List<Work> _createdWorks = new List<Work>();
		/// <summary>
		/// Устанавливает или задает коллекцию событий сетевого графики, которые могут быть удалены. 
		/// Поддерживает <see cref="System.ComponentModel.INotifyPropertyChanged"/>
		/// </summary>
		public ObservableCollection<Vertex> VerticesCanBeDeleted { get; set; } =
			new ObservableCollection<Vertex>();

		private Vertex _selectedVertexToDelete;
		/// <summary>
		/// Устанавливает или задает выбранное пользователем событие для удаления из сетевого графика.
		/// </summary>
		public Vertex SelectedVertexToDelete
		{
			get => _selectedVertexToDelete;
			set
			{
				Set(ref _selectedVertexToDelete, value);
				AdjacencyEdgesWillBeDeleted.Clear();
				List<Work> works;
				if (_selectedVertexToDelete == null || !_adjacencyList.TryGetValue(_selectedVertexToDelete.ID, out works))
					return;
				foreach (Work work in works)
				{
					AdjacencyEdgesWillBeDeleted.Add(work);
				}
			}
		}
		/// <summary>
		/// Устанавливает или задает коллекцию смежных работ сетевого графики, которые будут удалены при удалении выбранной работы
		/// <see cref="SelectedWorkToDelete"/>. 
		/// Поддерживает <see cref="System.ComponentModel.INotifyPropertyChanged"/>.
		/// </summary>
		public ObservableCollection<Work> AdjacencyEdgesWillBeDeleted { get; set; } =
			new ObservableCollection<Work>();
		/// <summary>
		/// Устанавливает или задает коллекцию работ, которые могут быть удалены пользователем.
		/// Поддерживает <see cref="System.ComponentModel.INotifyPropertyChanged"/>.
		/// </summary>
		public ObservableCollection<Work> WorksThatCanBeDeleted { get; set; } =
			new ObservableCollection<Work>();
		/// <summary>
		/// Устанавливает или задает работу, которую пользователь выбрал в интерфейсе для удаления из сетевого графика.
		/// </summary>
		public Work SelectedWorkToDelete { get; set; }

		private List<Work> _deletedWorks = new List<Work>();

		#endregion

		#region Commands

		#region ChoiceOfActionCommand
		/// <summary>
		/// Команда выбора действия, которое пользователь хочет произвести с сетевым графиком.
		/// </summary>
		public ICommand ChoiceOfActionCommand { get; }
		private void OnChoiceOfActionCommandExecuted(object p)
		{
			AddingFakeVertexIsNecessary = false;
			DeletingEdgesIsNecessary = false;
			DeletingVerticesIsNecessary = false;
			if ((string)p == "add fake")
				AddingFakeVertexIsNecessary = true;
			else if ((string)p == "delete edges")
				DeletingEdgesIsNecessary = true;
			else
				DeletingVerticesIsNecessary = true;
		}
		private bool CanChoiceOfActionCommandExecute(object p) => true;
		#endregion

		#region AddFakeVertexCommand
		/// <summary>
		/// Команда добавления искусственной вершины в сетевой график. Тип добавляемой вершины (начальная или конечная)
		/// зависит от <see cref="EditingMode"/>
		/// </summary>
		public ICommand AddFakeVertexCommand { get; }
		private void OnAddFakeVertexCommandExecuted(object p)
		{
			try
			{
				int fakeIndex = Convert.ToInt32(FakeVertexIndex);
				foreach (var vertex in _editingWindowData.Vertices)
				{
					if (vertex.ID == fakeIndex)
						throw new Exception($"Вершина {vertex.ID} уже существует");
				}
				string[] buffer = IndexesToConnectWithFakeVertex.Split(' ',
					StringSplitOptions.RemoveEmptyEntries);
				int[] indexesToConnect = new int[buffer.Length];
				for (int i = 0; i < buffer.Length; i++)
				{
					indexesToConnect[i] = Convert.ToInt32(buffer[i]);
				}
				ValidateIndexesToConnect(indexesToConnect, fakeIndex);
				Connect(fakeIndex, indexesToConnect);
				Status = "Вершина создана. Для того, чтобы изменения вступили в силу, нажмите 'ОК'";
			}
			catch (Exception e)
			{
				Status = e.Message;
			}
		}
		private bool CanAddFakeVertexCommandExecute(object p) => true;
		#endregion

		#region DeleteVerticesCommand
		/// <summary>
		/// Команда для удаления указанных пользователем событий из сетевого графика.
		/// </summary>
		public ICommand DeleteVerticesCommand { get; }
		private void OnDeleteVerticesCommandExecuted(object p)
		{
			try
			{
				_deletedVertices.Add(SelectedVertexToDelete);
				Status = $"Вершина {SelectedVertexToDelete.ID} удалена. Чтобы изменения вступили в силу, нажмите 'OK'";
				VerticesCanBeDeleted.Remove(SelectedVertexToDelete);
				AdjacencyEdgesWillBeDeleted.Clear();  // даже не нужно это делать
			}
			catch (Exception e)
			{
				Status = e.Message;
			}
		}
		private bool CanDeleteVerticesCommandExecute(object p) => SelectedVertexToDelete != null;
		#endregion

		#region DeleteEdgesCommand
		/// <summary>
		/// Команда для удаления работ, выбранных пользолвателем, из сетевого графика
		/// </summary>
		public ICommand DeleteEdgesCommand { get; }
		private void OnDeleteEdgesCommandExecuted(object p)
		{
			try
			{
				_deletedWorks.Add(SelectedWorkToDelete);
				Status = $"Работа {SelectedWorkToDelete} удалена";
				WorksThatCanBeDeleted.Remove(SelectedWorkToDelete);			
				SelectedWorkToDelete = null;
			}
			catch (Exception e)
			{
				Status = e.Message;
			}
		}
		private bool CanDeleteEdgesCommandExecute(object p) => SelectedWorkToDelete != null;
		#endregion

		#region AcceptCommand  
		/// <summary>
		/// Команда применения изменений к сетевому графику. То, какие изменения будут применены, зависит от <see cref="AddingFakeVertexIsNecessary"/>,
		/// <see cref="DeletingEdgesIsNecessary"/> и <see cref="DeletingVerticesIsNecessary"/>.
		/// </summary>
		public ICommand AcceptCommand { get; } // будут приняты только те изменения, которые 
											   // редактируются в данный момент, т.е. на 
											   // которые указывают флаги
		private void OnAcceptCommandExecuted(object p)
		{
			try
			{
				List<Work> toRemove = new List<Work>();
				string logMessage = "";
				if (AddingFakeVertexIsNecessary)
				{
					if (EditingMode == EditingMode.StartVertexMode)
					{
						_networkSchedule.Table.InsertRange(0, _createdWorks);
						_logger.LogMessage($"Добавлена начальная вершина с индексом: {_networkSchedule.Table[0].StartVertex.ID}");
					}
					else
					{
						_networkSchedule.Table.AddRange(_createdWorks);
						_logger.LogMessage($"Добавлена конечная вершина с индексом:" +
							$" {_networkSchedule.Table[_networkSchedule.Table.Count].EndVertex.ID}");
					}
				}
				else if (DeletingVerticesIsNecessary)
				{
					logMessage += "Удаление вершин\r\n";
					foreach (var vertex in _deletedVertices)
					{
						logMessage += $"\tУдаление вершины {vertex.ID}:\r\n";
						foreach (Work work in _networkSchedule.Table)
						{
							if (work.StartVertex == vertex || work.EndVertex == vertex)
							{
								toRemove.Add(work);
								logMessage += $"\t\tУдалена работа: {work}\r\n";
							}
						}
					}
				}
				else if (DeletingEdgesIsNecessary)
				{
					logMessage += "Удаление работ\r\n";
					foreach (Work work in _deletedWorks)
					{
						toRemove.Add(work);
						logMessage += $"\tУдалена работа: {work}\r\n";
					}
				}
				foreach (var work in toRemove)
				{
					_networkSchedule.Table.Remove(work);
				}
				_logger.LogMessage(logMessage);
				_logger.LogMessage("Изменения применены.");
				App.ActivedWindow?.Close();
			}
			catch (Exception e)
			{
				Status = e.Message;
			}
		}
		private bool CanAcceptCommandExecute(object p) => true;
		#endregion

		#endregion

		private void ValidateIndexesToConnect(int[] indexes, int fakeVertexIndex)
		{
			Array.Sort(indexes);
			if (indexes[0] == fakeVertexIndex)
				throw new Exception($"Попытка соединить врешину {fakeVertexIndex} и" +
					$" {indexes[0]} недопустима");
			if (!_editingWindowData.Vertices.Contains(_networkSchedule.GetVertexById(indexes[0])))
				throw new Exception($"Вершина {indexes[0]} не существует " +
					$"в исходной таблице");
			for (int i = 0; i < indexes.Length - 1; i++)
			{
				if (indexes[i] == indexes[i + 1])
					throw new Exception($"Повторение вершин в списке для соединения: " +
						$"{indexes[i]} и {indexes[i + 1]}");
				else if (indexes[i + 1] == fakeVertexIndex)
					throw new Exception($"Попытка соединить врешину {fakeVertexIndex} и" +
						$" {indexes[i + 1]} недопустима");
				else if (!_editingWindowData.Vertices.Contains(_networkSchedule.GetVertexById(indexes[i + 1])))
					throw new Exception($"Вершина {indexes[i + 1]} не существует " +
						$"в исходной таблице");
			}
		}

		private void Connect(int fakeVertexIndex, int[] indexes)
		{
			_createdWorks.Clear();
			Vertex vertex;
			if (EditingMode == EditingMode.StartVertexMode)
			{
				for (int i = 0; i < indexes.Length; i++)
				{
					if ((vertex = _networkSchedule.GetVertexById(fakeVertexIndex)) == null)
						vertex = new Vertex(fakeVertexIndex);
					_createdWorks.Add(new Work(vertex,
						_networkSchedule.GetVertexById(indexes[i]), 0));
				}
			}
			else
			{
				for (int i = 0; i < indexes.Length; i++)
				{
					if ((vertex = _networkSchedule.GetVertexById(fakeVertexIndex)) == null)
						vertex = new Vertex(fakeVertexIndex);
					_createdWorks.Add(new Work(_networkSchedule.GetVertexById(indexes[i]),
						vertex, 0));
				}
			}
		}

		private void PrepareVerticesDeleting()
		{
			VerticesCanBeDeleted.Clear();
			AdjacencyEdgesWillBeDeleted.Clear();
			_adjacencyList = new Dictionary<int, List<Work>>();
			List<Work> works;
			foreach (var vertex in _editingWindowData.Vertices)
			{
				VerticesCanBeDeleted.Add(vertex);
				works = new List<Work>();
				foreach (Work work in _networkSchedule.Table)
				{
					if (work.StartVertex == vertex || work.EndVertex == vertex)
						works.Add(work);
				}
				_adjacencyList.Add(vertex.ID, works);
			}
		}

		private void PrepareEdgesDeleting()
		{
			WorksThatCanBeDeleted.Clear();
			foreach (var vertex in _editingWindowData.Vertices)
			{
				foreach (Work work in _networkSchedule.Table)
				{
					if (work.StartVertex.ID == vertex.ID || work.EndVertex.ID == vertex.ID)
						WorksThatCanBeDeleted.Add(work);
				}
			}
		}
	}

	/// <summary>
	/// Режим редактирования, в котором следует работать окну <see cref="Views.Windows.EditWindow"/>
	/// </summary>
	public enum EditingMode
	{
		/// <summary>
		/// Указывает, что следует работать с начальными вершинами сетевого графика.
		/// </summary>
		StartVertexMode,
		/// <summary>
		/// Указывает, что следует работать с конечными вершинами сетевого графика.
		/// </summary>
		EndVertexMode
	}
}
